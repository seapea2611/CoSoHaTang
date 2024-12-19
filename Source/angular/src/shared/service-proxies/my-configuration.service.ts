import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AppConsts } from '@shared/AppConsts';

@Injectable({
  providedIn: 'root',
})
export class MyConfigurationService {
  private readonly baseUrl: string = AppConsts.remoteServiceBaseUrl;

  constructor(private http: HttpClient) {}

  getMyConfiguration(): Observable<any> {
    const url = this.baseUrl + '/api/services/app/MyConfiguration/GetMyConfiguration'; // Update the path if necessary
    return this.http.get<any>(url);
  }
}
