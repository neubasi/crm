import { Component, OnInit } from '@angular/core';
import { StammdatenService } from './stammdaten.service';
import {FormControl, FormGroupDirective, NgForm, Validators} from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';

/** Error when invalid control is dirty, touched, or submitted. */
export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}

@Component({
  selector: 'app-stammdaten',
  templateUrl: './stammdaten.component.html',
  styleUrls: ['./stammdaten.component.scss']
})
export class StammdatenComponent implements OnInit {

  artikel: Array<Artikel>;
  kunden: Array<Kunde>;
  bestellungen: Array<BestellungGUI>;

  modelArtikel = new Artikel();
  modelKunde = new Kunde();
  modelBestellung = new BestellungGUI();
  submitted = false;

  /*
  selected = new FormControl('valid', [
    Validators.required,
    Validators.pattern('valid'),
  ]);

  selected2 = new FormControl('valid', [
    Validators.required,
    Validators.pattern('valid'),
  ]);*/

 
  matcher = new MyErrorStateMatcher();



  ArtikelMap = new Map();
  KundeMap = new Map();

  constructor(public dataService: StammdatenService) { }

  ngOnInit(): void {
    this.getArtikel();
    this.getKunden();
    this.getBestellungen();
  }

  getArtikel() {
    this.dataService.getData('Artikel').subscribe((data: Array<Artikel>) => {
      // console.log(data);
      this.artikel = data;
      this.artikel.forEach(element => {
        this.ArtikelMap.set(element.id, element.name);
      });
    });

  }

  getKunden() {
    this.dataService.getData('Kunde').subscribe((data: Array<Kunde>) => {
      // console.log(data);
      this.kunden = data;
      this.kunden.forEach(element => {
        this.KundeMap.set(element.id, element.name);
      });
    });
  }

  getBestellungen() {
    this.dataService.getData('Bestellung').subscribe((data: Array<BestellungGUI>) => {
    //  console.log(data);
      this.bestellungen = data;
    });
  }

  addData(stammdaten: string) {
    console.log( this.modelBestellung)
    let stamm;
    if (stammdaten === 'Kunde') { stamm = this.modelKunde; }
    if (stammdaten === 'Artikel') { stamm = this.modelArtikel; }
    if (stammdaten === 'Bestellung') { stamm = this.modelBestellung; }
    this.dataService.addData(stammdaten, stamm).subscribe(() => {
      this.getArtikel();
      this.getBestellungen();
      this.getKunden();
      this.dataService.progressSpinner(true, 'Speichern...');
    }, error => {
      this.dataService.progressSpinner(false, 'Error: ' + JSON.stringify(error));
      console.log(error)
    });
  }

  deleteData(stammdaten: string, id: number) {
    this.dataService.deleteData(`${stammdaten}/${id}`).subscribe(data => {
      this.getArtikel();
      this.getBestellungen();
      this.getKunden();
      this.dataService.progressSpinner(true, 'Speichern...');
    });
  }


  onSubmit() { this.submitted = true; }

}

class Artikel {
  name: string;
  einheit: string;
  preis: number;
  id: number;
}

class Kunde {
  name: string;
  id: number;
}

class BestellungGUI {
  text: string;
  id: number;
  artikelId: number;
  artikelText: string;
  kundeId: number;
  kundeText: string;
  menge: number;
  betrag: number;
}

/*
class BestellungDB {
  text: string;
  menge: number;
  artikelId: number;
  kundeId: number;
}*/

