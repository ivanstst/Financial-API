import { HttpClient, HttpErrorResponse, HttpHeaders } from "@angular/common/http";
import { environment } from "../../environments/environment";
import { Injectable, inject } from "@angular/core";
import { Observable, catchError, map, throwError } from "rxjs";
import { Symbols } from "../models/Symbols";
import { Datapoints } from "../models/Datapoints";

@Injectable({
  providedIn: 'root'
})

export class ChartsService {
  private getSymbolsUrl = environment.baseApiUrl + environment.apiUrl + environment.symbolsUrl;
  private getViewByIdUrl = environment.baseApiUrl + environment.viewByIdUrl;
  private getChartDataUrl = environment.baseApiUrl + environment.apiUrl + environment.chartUrl;
  
  constructor(private http: HttpClient) { }

  getSymbolsData(): Observable<Symbols[]> {
    return this.http.get<Symbols[]>(this.getSymbolsUrl)
      .pipe(
        map(data => data),
        catchError(error => {
          console.error(error);
          return throwError(error);
        })
      );
  }
  getChartById(id: number): Observable<any> {
    return this.http.get<any>(this.getViewByIdUrl + '/' + id);
  }
  getIntervalsData() {
    return ['30m', '4h', '1d']
  }

  getChartData(symbolValue: string, intervalValue: string) {

    //get datapoints
    var datapoints: Datapoints[] = [];

    this.http.get<any>(this.getChartDataUrl + symbolValue + "/datapoints" + '?interval=' + intervalValue)
      .subscribe(dp => datapoints = dp);

    //get average price
    var averagePriceData: Number[] = [];

    this.http.get<any>(this.getChartDataUrl + symbolValue + "/average")
      .subscribe(ap => averagePriceData = ap);

    return { datapoints, averagePriceData };
  }
  getChartOptions() {
    return {
      title: {
        display: true,
        text: 'My Title'
      }
    }
  }

  getAveragePriceData(selectedSymbol: string) {
    return {
      "mins": 5,
      "price": "48241.11641276",
      "closeTime": 1707639667679
    }
  }
}