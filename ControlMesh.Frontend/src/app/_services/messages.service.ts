import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Message } from '../_models/message';
import { PaginatedResult } from '../_models/paginated-result';

@Injectable({
    providedIn: 'root'
})
export class MessagesService {
    baseUrl = environment.apiUrl;

    constructor(private http: HttpClient) { }

    getMessages() {
        return this.http.get<PaginatedResult<Message>>(this.baseUrl + 'messages');
    }

    paginatedMessages(rows: number, event: any) {
        return this.http.get<PaginatedResult<Message>>(this.baseUrl + 'messages?page='
            + (Math.round(event.first / event.rows + 1)) + '&pageSize=' + rows);
    }

    getMessageById(id: number) {
        return this.http.get<Message>(this.baseUrl + 'messages/' + id).pipe(
            catchError((err) => {
                console.log(err);
                return throwError(() => err)
            }),
        );
    }
}