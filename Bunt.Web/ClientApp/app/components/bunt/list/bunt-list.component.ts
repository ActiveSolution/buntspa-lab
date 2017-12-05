import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { BuntladeStalle } from "../../../models/buntladeStalle.model"

@Component({
    selector: 'bunt',
    templateUrl: './bunt-list.component.html'
})
export class BuntListComponent implements OnInit {
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

    public taBort(buntladeStalle: BuntladeStalle) {
        this.http.delete(`/api/bunt/${buntladeStalle.id}`).subscribe(data => {
            this.buntladeStallen.splice(this.buntladeStallen.indexOf(buntladeStalle), 1);
        });
    }

}
