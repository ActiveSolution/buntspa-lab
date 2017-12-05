import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { BuntladeStalle } from "../../models/buntladeStalle.model"

@Component({
    selector: 'bunt',
    templateUrl: './bunt.component.html'
})
export class BuntComponent implements OnInit {
    private http: Http;

    constructor(http: Http) {
        this.http = http;
    }

    ngOnInit(): void {
        this.http.get("/api/bunt").subscribe(data => {
            this.buntladeStallen = data.json();
        });
    }

    public buntladeStallen: BuntladeStalle[];

}
