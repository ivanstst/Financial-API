import { Component, Input, inject } from '@angular/core';
import { ChartModule } from 'primeng/chart';
import { ChartsService } from '../services/charts.service';
import { ButtonModule } from 'primeng/button';
import { FormControl, FormsModule, ReactiveFormsModule, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastModule } from 'primeng/toast';
import { InputGroupModule } from 'primeng/inputgroup';
import { InputGroupAddonModule } from 'primeng/inputgroupaddon';
import { SelectButtonModule } from 'primeng/selectbutton';
import { Symbols } from '../models/Symbols';
@Component({
  selector: 'app-chart',
  standalone: true,
  imports: [
    ChartModule,
    ButtonModule,
    FormsModule,
    ToastModule,
    InputGroupModule,
    InputGroupAddonModule,
    SelectButtonModule,
    ReactiveFormsModule
  ],
  templateUrl: './chart.component.html',
  styleUrl: './chart.component.scss'
})
export class ChartComponent {
  symbolsToggleButtons: Symbols[] = [];
  chartGroup: FormGroup;
  averagePriceData: any[] = [];

  constructor(router: Router) {
    this.chartGroup = new FormGroup({
      symbolValue: new FormControl(''),
      intervalValue: new FormControl('30m') 
    });
    this.options = {
      title: {}
    }
    this.router = router;
  }

  ngOnInit() {
    this.chartService.getSymbolsData().subscribe(
      (symbols: Symbols[]) => {
        this.symbolsToggleButtons = symbols;
        if (symbols.length > 0) {
          // Set the first symbol name as the default value
          this.chartGroup.get('symbolValue')?.setValue(symbols[0].name);
        }
      },
      (error) => {
        console.error('Error fetching symbols data', error);
      }
    );
  }
  private router: Router;
  private chartService = inject(ChartsService);

  intervalsToggleButtons = [
    { id: 1, value: '30m', state: true },
    { id: 2, value: '4h', state: false },
    { id: 3, value: '1d', state: false }
  ];

  private view$: any;
  @Input()
  set id(viewId: number) {
    this.view$ = this.chartService.getChartById(viewId);
    console.log(this.view$);
  }

  symbolSeleced: string = '';
  currentUser: string = localStorage.getItem('user') || '';

  //BEGIN Set the chart data
  options: any;
  documentStyle = getComputedStyle(document.documentElement);
  textColor = this.documentStyle.getPropertyValue('--text-color');
  textColorSecondary = this.documentStyle.getPropertyValue('--text-color-secondary');
  surfaceBorder = this.documentStyle.getPropertyValue('--surface-border');
  data: any = {
    labels: [
      "2024-02-11T00:01:17.000Z",
      "2024-02-11T00:03:20.000Z",
      "2024-02-11T00:05:29.000Z",
      "2024-02-11T00:07:20.000Z",
      "2024-02-11T00:09:03.000Z",
      "2024-02-11T00:11:00.000Z",
      "2024-02-11T00:12:53.000Z",
      "2024-02-11T00:14:40.000Z",
      "2024-02-11T00:16:30.000Z",
      "2024-02-11T00:18:00.000Z",
      "2024-02-11T00:19:33.000Z",
      "2024-02-11T00:21:00.000Z",
      "2024-02-11T00:22:30.000Z",
      "2024-02-11T00:24:47.000Z",
      "2024-02-11T00:26:43.000Z",
      "2024-02-11T00:28:40.000Z",
      "2024-02-11T00:30:10.000Z",
      "2024-02-11T00:31:50.000Z",
      "2024-02-11T00:33:00.000Z",
      "2024-02-11T00:34:40.000Z"
    ],
    datasets: [
      {
        label: 'Average Price',
        // data: this.averagePriceData,
        data: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20],
        fill: false,
        tension: 0.4,
        borderColor: this.documentStyle.getPropertyValue('--blue-500'),
        backgroundColor: 'rgba(255,167,38,0.2)'
      },

      {
        label: 'Open Pricet',
        data: [12, 51, 62, 33, 21, 62, 45, 12, 51, 62, 33, 21, 62, 45, 12, 51, 62, 33, 21, 62,],
        fill: true,
        borderColor: this.documentStyle.getPropertyValue('--orange-500'),
        tension: 0.4,
        backgroundColor: 'rgba(255,167,38,0.2)'
      }
    ]
  };
  //END Set the chart data

  goToAllViews() {
    this.router.navigate(['/list-view']);
  }


  updateIntervalSelected() {
    console.log('Interval selected: ', this.chartGroup);

    this.refreshChart(this.chartGroup.value.symbolValue || "", this.chartGroup.value.intervalValue || "");
  }
  refreshChart(symbolValue: string, intervalValue: string) {
    var res = this.chartService.getChartData(symbolValue, intervalValue);
    this.averagePriceData = res.averagePriceData;
    console.log("res data: " + res);
    console.log(this.averagePriceData);
  }
}
