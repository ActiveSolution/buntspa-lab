import { Component } from '@angular/core';
import { BuntladeStalle } from "../../models/buntladeStalle.model"

@Component({
    selector: 'bunt',
    templateUrl: './bunt.component.html'
})
export class BuntComponent {
    public buntladeStallen: BuntladeStalle[];

    constructor() {
        this.buntladeStallen = [
            { index: 0, adress: "Testgatan 1", typ: "Lämna", buntladeNummer: 0 },
            { index: 1, adress: "Testgatan 2", typ: "Hämta", buntladeNummer: 1 }
        ];
    }
}
