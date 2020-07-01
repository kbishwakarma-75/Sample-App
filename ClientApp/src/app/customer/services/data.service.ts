import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private http: HttpClient) { }

  getCustomers(url: string): Observable<any> {
    return this.http.get(url, { headers: this.getHeaders() })
      .pipe(catchError((error) => {
        this.handleError(error);
        return throwError(error);
      }));
  }

  addCustomer(url: string, data: any): Observable<any> {
    const body = JSON.stringify(data);
    return this.http.post(url, body, { headers: this.getHeaders() })
      .pipe(catchError((error) => {
        this.handleError(error);
        return throwError(error);
      }));
  }

  deleteCustomer(url: string, id: any): Observable<any> {
    return this.http.post(url + "?id=" + id, {}, { headers: this.getHeaders() })
      .pipe(catchError((error) => {
        this.handleError(error);
        return throwError(error);
      }));
  }

  private getHeaders() {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json');
    return headers;
  }

  handleError(error) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return errorMessage;
  }

}
