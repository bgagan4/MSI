import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ISubjectAddress } from './types';

@Injectable({
  providedIn: 'root'
})
export class ApiServiceService {

  baseURL: string = "https://localhost:44363/";

  constructor(private http: HttpClient) { }

  saveSubjectAddress(subjectAddress:ISubjectAddress):Observable<any> {
    

    const headers = { 'content-type': 'application/json'}  
    const body=JSON.stringify(subjectAddress);

    console.log(body);

    return this.http.post<ISubjectAddress>(this.baseURL + 'api/SubjectAddress', body,{'headers':headers , observe: 'response'})
  }

}