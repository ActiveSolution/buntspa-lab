import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { Http } from '@angular/http';
import { BsModalService } from 'ngx-bootstrap/modal';
import { BsModalRef } from 'ngx-bootstrap/modal/modal-options.class';

import { BuntladeStalle } from "../../../models/buntladeStalle.model"

@Component({
    selector: 'bunt',
    templateUrl: './bunt-list.component.html'
})
export class BuntListComponent implements OnInit {
    private modalService: BsModalService;
    private http: Http;

    constructor(http: Http, modalService: BsModalService) {
        this.modalService = modalService;
        this.http = http;
    }

    ngOnInit(): void {
        this.http.get("/api/bunt").subscribe(data => {
            this.buntladeStallen = data.json();
        });
    }

    @ViewChild('editModal') editModalTemplate: TemplateRef<any>;

    modalRef: BsModalRef;
    buntladeStallen: BuntladeStalle[];
    selectedBuntladeStalle: BuntladeStalle | undefined;

    taBort(buntladeStalle: BuntladeStalle) {
        this.http.delete(`/api/bunt/${buntladeStalle.id}`).subscribe(data => {
            this.buntladeStallen.splice(this.buntladeStallen.indexOf(buntladeStalle), 1);
        });
    }

    redigera(buntladeStalle: BuntladeStalle) {
        this.selectedBuntladeStalle = buntladeStalle;
        this.modalRef = this.modalService.show(this.editModalTemplate);
    }

    avbrytRedigera() {
        this.selectedBuntladeStalle = undefined;
        this.modalRef.hide();
    }

    spara() {
        if (this.selectedBuntladeStalle) {
            this.http.put(`/api/bunt/${this.selectedBuntladeStalle.id}`,
                {
                    adress: this.selectedBuntladeStalle.adress,
                    typ: this.selectedBuntladeStalle.typ
                }).subscribe(() => {
                    this.avbrytRedigera();
            });
        }
    }
}
