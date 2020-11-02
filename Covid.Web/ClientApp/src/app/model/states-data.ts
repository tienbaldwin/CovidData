import { DatesData } from './dates-data';



export class StateData
{
    public selected: boolean | null;

    public stateAbbreviation: string;

    public stateName: string;

    public allDaysData: DatesData[];

    public dates: Date[];

    public mostRecentTotalCases: number | null;

    public projectedTotalCases: number | null;

    public mostRecentNewCases: number | null;

    public mostRecentTotalDeaths: number | null;

    public projectedTotalDeaths: number | null;

    public mostRecentNewDeaths: number | null;


}

