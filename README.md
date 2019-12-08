# TopTenMovies

### This Is A Mini Web Application Whose Goal Is To Display A List Of Top Ten Movies Of All Times, It Also Enables Filtering Movies By Genre, Replacing Least Rated Movie With A New One.

### This Mini WebApp Is Written In The Following Technologies:-

1. Back-End:-
    - ASP.NET Web Api
    - WCF
    - ASP.NET MVC

2. Front-End:-
    - Angular 8
    - ng-bootstrap
    - bootstrap
    - RxJs
<br />
<br />
### Prerequisites:
```
        .NET Framework 4.7.1
        Microsoft IIS (+ Manager)
```

### Setup:
```
    1) npm install -g @angular/cli

    TopTenMovies.API & TopTenMovies.APP Projects:-

        2) Add The Following Lines To Hosts File:-

            127.0.0.1  toptenmovies.api
            127.0.0.1  toptenmovies.wcf

        3) Create 2 Web Sites Using IIS With The Following Names:-

            TopTenMovies.API
            TopTenMovies.APP
        
        4) Set Their Physical Path To Their Corresponding Folder:-

            TopTenMovies.API Folder
            TopTenMovies.APP Folder
        
        5) bind them with the following hostnames:-

            - toptenmovies.api for toptenmovies.api website
            - toptenmovies.wcf for toptenmovies.app website
    
    Inside TopTenMovies.WEB Web Application Folder:

        6) npm install
        7) ng serve --open
```