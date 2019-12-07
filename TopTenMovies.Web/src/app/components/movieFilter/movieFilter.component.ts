import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Genre } from '../../models/genre';
import { Movie } from '../../models/movie';
import { MovieStorage } from '../../services/storage/movieStorage.service';
import { GenreStorage } from '../../services/storage/genreStorage.service';

@Component({
  selector: 'movieFilter',
  templateUrl: './movieFilter.component.html',
  styleUrls: ['./movieFilter.component.css']
})
export class MovieFilterComponent implements OnInit {
  genres: Genre[];
  movies: Movie[];
  filteredMovies: Movie[];
  // tslint:disable-next-line:no-output-on-prefix
  @Output() onUpdateFilterVal: EventEmitter<number> = new EventEmitter();

  constructor(
    private movieStorage: MovieStorage,
    private genreStorage: GenreStorage) {
      this.genres = [];
      this.movies = [];
    }

  ngOnInit() {
    const genresStorage = this.genreStorage.get();
    const moviesStorage = this.movieStorage.get();

    genresStorage
        .subscribe(genres => {
          this.genres = genres;
        });

    moviesStorage
        .subscribe(movies => {
          this.movies = movies;
        });
  }

  filterMoviesByGenre(genreID: number) {
    this.onUpdateFilterVal.emit(genreID);
  }
}
