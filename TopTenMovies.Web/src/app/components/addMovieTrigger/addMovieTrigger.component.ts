import { Component } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AddMovieFormModalComponent } from '../addMovieFormModal/addMovieFormModal.component';

@Component({
  selector: 'addMovieTrigger',
  templateUrl: './addMovieTrigger.component.html',
  styleUrls: ['./addMovieTrigger.component.css']
})
export class AddMovieTriggerComponent {
  constructor(private modalService: NgbModal) {}

  openFormModal() {
    this.modalService.open(AddMovieFormModalComponent);
  }
}
