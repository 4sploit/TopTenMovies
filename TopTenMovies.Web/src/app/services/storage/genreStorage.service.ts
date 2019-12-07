import { Injectable } from '@angular/core';
import { Genre } from './../../models/genre';
import { Storage } from './Storage.service';

@Injectable({
  providedIn: 'root'
})
export class GenreStorage extends Storage<Genre[]> {
  constructor() {
    super([]);
  }
}
