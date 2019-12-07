import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Movie } from './../../models/movie';

const apiUrl = 'http://toptenmovies.api/api/movie';
const httpOptions = {
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    })
};

@Injectable({
  providedIn: 'root'
})

export class MovieApiService {
    constructor(private httpClient: HttpClient) {}

    fetchMovies(): Observable<HttpResponse<Movie[]>> {
        return this.httpClient
                   .get<Movie[]>(`${apiUrl}/fetchMovies`, { observe: 'response' });
    }

    addMovie(movie: Movie): Observable<Movie> {
        return this.httpClient
            .post<Movie>(`${apiUrl}/add`, movie);
    }
}
