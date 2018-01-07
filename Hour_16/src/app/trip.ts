export class Trip {
    Destination: string;
    DurationInDays: number;

    constructor(destination: string, durationInDays: number) {
        this.Destination = destination;
        this.DurationInDays = durationInDays;
    }

    public get longTrip(): boolean {
        return this.DurationInDays > 3;
    }

}
