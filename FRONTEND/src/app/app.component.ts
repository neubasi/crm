import { Component } from '@angular/core';
import { StammdatenService } from './stammdaten/stammdaten.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'FRONTEND';

  progressOn;

  constructor(public dataService: StammdatenService) {

    this.dataService.progressOn.subscribe(data => this.progressOn = data);
  }

}
