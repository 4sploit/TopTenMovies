import { Component, Input, OnInit, OnChanges } from '@angular/core';
import { Movie } from '../../models/movie';
import { MovieStorage } from '../../services/storage/movieStorage.service';

@Component({
  selector: 'movieList',
  templateUrl: './movieList.component.html',
  styleUrls: ['./movieList.component.css']
})
export class MovieListComponent implements OnInit {
  @Input() movies: Movie[] = [];
  @Input() filterVal: number;

  constructor(private movieStorage: MovieStorage) {}

  ngOnInit() {
    this.movieStorage.get().subscribe(movieList => {
      this.movies = [...movieList];
    });
  }
}
