import { Injectable } from '@angular/core';
import { Movie } from './../../models/movie';
import { Storage } from './Storage.service';

@Injectable({
  providedIn: 'root'
})
export class MovieStorage extends Storage<Movie[]> {
  constructor() {
    super([]);
  }
}
