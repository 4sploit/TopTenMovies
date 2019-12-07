import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Genre } from './../../models/genre';

const apiUrl = 'http://toptenmovies.api/api/genre';

@Injectable({
  providedIn: 'root'
})

export class GenreApiService {
    constructor(private httpClient: HttpClient) {}

    fetchGenres(): Observable<HttpResponse<Genre[]>> {
        return this.httpClient
                   .get<Genre[]>(`${apiUrl}/fetchGenres`, { observe: 'response' });
    }
}
