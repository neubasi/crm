import { Component, OnInit } from '@angular/core';
import { StammdatenService } from './stammdaten.service';

@Component({
  selector: 'app-stammdaten',
  templateUrl: './stammdaten.component.html',
  styleUrls: ['./stammdaten.component.scss']
})
export class StammdatenComponent implements OnInit {

  artikel: Array<Artikel>;
  kunden: Array<Kunde>;
  bestellungen: Array<Bestellung>;

  modelArtikel = new Artikel();
  modelKunde = new Kunde();
  modelBestellung = new Bestellung();
  submitted = false;




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
    this.dataService.getData('Bestellung').subscribe((data: Array<Bestellung>) => {
     // console.log(data);
      this.bestellungen = data;
    });
  }

  addData(stammdaten: string) {
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


  getArtikelbyId(id: any) {
      return this.ArtikelMap.get(id);
  }

  getKundebyId(id: any) {
    return this.KundeMap.get(id);
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

class Bestellung {
  text: string;
  id: number;
  fK_Artikel: number;
  fK_Kunde: number;
}

