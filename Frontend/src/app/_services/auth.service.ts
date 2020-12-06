import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { map } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { User } from '../_models/user';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl = 'http://icreatesites4u.com/api/auth/';
  jwtHelper = new JwtHelperService();
  decodedToken: any;
  currentUser: User;
  photoUrl = new BehaviorSubject<string>('../../assets/user.png');
  currentPhotoUrl = this.photoUrl.asObservable();

constructor(private http: HttpClient) { }

    // tslint:disable-next-line: typedef
    changeMemberPhoto(photoUrl: string) {
      this.photoUrl.next(photoUrl);
    }
  // tslint:disable-next-line: typedef
  login(model: any) {
    return this.http.post(this.baseUrl + 'login', model).pipe(
      map((response: any) => {
         const user = response;
         if (user) {
              localStorage.setItem('token', user.token);
              localStorage.setItem('user', JSON.stringify(user.user));
              this.decodedToken = this.jwtHelper.decodeToken(user.token);
              this.currentUser = user.user;
              this.changeMemberPhoto(this.currentUser.photoUrl);
          }
      })
    );
  }

  // tslint:disable-next-line: typedef
  loggedIn() {
    const token = localStorage.getItem('token');
    return !this.jwtHelper.isTokenExpired(token);
  }

}
