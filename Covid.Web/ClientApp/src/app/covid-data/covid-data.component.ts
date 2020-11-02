import { Component, OnInit } from '@angular/core';
import { GridDataResult } from '@progress/kendo-angular-grid';
import { IntlService } from '@progress/kendo-angular-intl/dist/es2015/intl.service';
import { orderBy, SortDescriptor } from '@progress/kendo-data-query';
import { CovidDataService } from '../covid-dara.service';
import { StateData } from '../model/states-data';


@Component({
  selector: 'app-covid-data',
  templateUrl: './covid-data.component.html'
})
export class CovidDataComponent  {
  private myData: StateData[] = [];
  private isBusy: boolean = false;
  private selectedState: StateData;
  private selectedStates: StateData[] = [];
  private selectedStatesKeys: string[] = [];
  private showChartComponent: boolean = false;

  public gridView: GridDataResult;
  public sort: SortDescriptor[] = [{
    field: 'mostRecentNewCases',
    dir: 'desc'
  }];

  constructor(private covidService: CovidDataService
    , private intl: IntlService) { }

  public GetCovidData() {
    if (this.myData.length > 0) {
      this.gridView = {
        data: orderBy(this.myData, this.sort),
        total: this.myData.length
      };
      return;
    }
    this.isBusy = true;
    this.selectedState = null;
    this.selectedStates = [];
    this.selectedStatesKeys = [];

    this.covidService.getCovidDate()
                    .subscribe(data=> {
                      this.myData = data.sort((a,b) => a.mostRecentNewCases > b.mostRecentNewCases ? -1 : 1 );
                      for(var i = 0; i < this.myData.length; i++){
                        for (var j = 0; j < this.myData[i].allDaysData.length; j++){
                          this.myData[i].allDaysData[j].myParsedDate = this.intl.parseDate(this.myData[i].allDaysData[j].theDate.toString());
                        }
                      }
                      this.gridView = {
                        data: orderBy(this.myData, this.sort),
                        total: this.myData.length
                      }; 
                      this.isBusy = false; 
                    })
  }


}
