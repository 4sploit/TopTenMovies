import { Component, Input, OnInit } from '@angular/core';
import { Movie } from '../../models/movie';
import {FormControl, Validators} from '@angular/forms';

@Component({
  selector: 'movie',
  templateUrl: './movie.component.html',
  styleUrls: ['./movie.component.css']
})
export class MovieComponent implements OnInit {
  @Input() movie: Movie;
  ratingCtrl = new FormControl(null, Validators.required);
  isVisible = false;

  constructor() {}

  ngOnInit() {
    this.ratingCtrl.disable();

    this.ratingCtrl.setValue(this.movie.Rating);
  }

  toggleRatingAndGenreVisibility() {
    this.isVisible = !this.isVisible;
  }
}
