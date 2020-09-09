import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class StammdatenService {

  constructor(private http: HttpClient) { }

  getData(url: string) {
    return this.http.get(`http://localhost:5000/api/${url}`);
  }

  addData(url: string, data: any) {
    console.log(data)
    return this.http.post(`http://localhost:5000/api/${url}`, data);
  }

  deleteData(url: string) {
    console.log(url)
    return this.http.delete(`http://localhost:5000/api/${url}`);
  }
}
