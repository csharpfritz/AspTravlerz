export class Trip {
    id: number;
    name: string;
    description: string;
    startDate: Date;
    endDate: Date;
    segments: any;

    private MsPerDay = 24 * 60 * 60 * 1000;

    public constructor(id: number, name: string, desc: string, startDate: Date, endDate: Date) {
        this.id = id;
        this.name = name;
        this.description = desc;
        this.startDate = new Date(startDate);
        this.endDate = new Date(endDate);
    }

    public get Destination(): string {
        return this.name;
    }

    public get DurationInDays(): number {
        return Math.floor( (this.endDate.valueOf() - this.startDate.valueOf())
            / this.MsPerDay);
    }

    public get longTrip(): boolean {
        return this.DurationInDays > 3;
    }


}
