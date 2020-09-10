import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StammdatenService {

  progressOn = new BehaviorSubject(false);
  progressMessage;
  progressColor = 'rgb(70,70,70)';

  constructor(private http: HttpClient) { }

  getData(url: string) {
    return this.http.get(`http://localhost:5000/api/${url}`);
  }

  addData(url: string, data: any) {
    console.log(data)
    return this.http.post(`http://localhost:5000/api/${url}`, data)
  }

  deleteData(url: string) {
    console.log(url)
    return this.http.delete(`http://localhost:5000/api/${url}`);
  }

  progressSpinner(success: boolean, message: string) {
    if (success === true) {
      this.progressOn.next(true);
      this.progressMessage = message;
      this.progressColor = 'rgb(34,177,76)';
      setTimeout(() => {
        this.progressOn.next(false);
        this.progressColor = 'rgb(70,70,70)';
      }, 400);
    } else {
      console.log("hallo")
      this.progressOn.next(true);
      this.progressMessage = message;
      this.progressColor = 'rgb(255,0,0)';
    }
  }
}
