import { Component, Inject, OnInit } from '@angular/core';
import { Customer } from './models/models';
import { DataService } from './services/data.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {
  public customers: Customer[];
  formGroup: FormGroup;
  submitted = false;

  constructor(private formBuilder: FormBuilder,
    private customerService: DataService,
    @Inject('BASE_URL') private baseUrl: string) {
    this.getCustomers();
  }

  ngOnInit() {
    this.formGroup = this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      phoneNumber: [''],
      birthMonth: [null, [Validators.min(1), Validators.max(12)]],
      birthYear: [null, [Validators.min(1900), Validators.max(2020)]],
    });
  }

  ngOnDestroy() {

  }

  resetFormValue() {
    this.formGroup.controls.firstName.setValue('');
    this.formGroup.controls.lastName.setValue('');
    this.formGroup.controls.email.setValue('');
    this.formGroup.controls.phoneNumber.setValue('');
    this.formGroup.controls.birthMonth.setValue(null);
    this.formGroup.controls.birthYear.setValue(null);
  }

  // convenience getter for easy access to form fields
  get f() { return this.formGroup.controls; }

  private getCustomers() {
    this.customerService.getCustomers(this.baseUrl + 'api/customer/GetAllCustomers').subscribe(result => {
      this.customers = result;
    }, error => console.error(error));
  }

  public addCustomer() {
    this.submitted = true;
    var formResult = this.formGroup.value;

    // stop here if form is invalid
    if (this.formGroup.invalid) {
      return;
    }

    let newCustomer = new Customer();

    newCustomer.firstName = formResult.firstName;
    newCustomer.lastName = formResult.lastName;
    newCustomer.email = formResult.email;
    newCustomer.phoneNumber = formResult.phoneNumber;
    newCustomer.birthMonth = formResult.birthMonth;
    newCustomer.birthYear = formResult.birthYear;

    var url = this.baseUrl + 'api/customer/AddNewCustomer';

    this.customerService.addCustomer(url, newCustomer).subscribe(result => {
      this.getCustomers();
      this.resetFormValue();
      this.submitted = false;
    }, error => console.error(error));

  }

  public deleteCustomer(id: number) {
    var url = this.baseUrl + 'api/customer/DeleteCustomer';
    this.customerService.deleteCustomer(url, id).subscribe(result => {
      console.log(result);
      this.getCustomers();
    }, error => console.error(error));
  }

}
