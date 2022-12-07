# How to get the month and year of month view in Xamarin.Forms Schedule (SfScheduler)

You can get the month and year of month view by using the VisibleDatesChanged[https://help.syncfusion.com/cr/xamarin/Syncfusion.SfSchedule.XForms.SfSchedule.html#Syncfusion_SfSchedule_XForms_SfSchedule_VisibleDatesChangedEvent] event in Xamarin [SfSchedule](https://www.syncfusion.com/xamarin-ui-controls/xamarin-scheduler).

**XAML**

Set the schedule view as `MonthView`. Binding the behavior to the SfSchedule to handle the `VisibleDatesChanged` event handler.
```
<ContentPage.Content>
        <Grid>
            <schedule:SfSchedule x:Name="Schedule"
                                 ScheduleView="MonthView">
            </schedule:SfSchedule>
        </Grid>
    </ContentPage.Content>
    <ContentPage.Behaviors>
        <local:SchedulerPageBehavior/>
    </ContentPage.Behaviors>
```
**C#**

In `VisibleDatesChanged`, you can get the month and year of month view by using the `VisibleDates` property of `VisibleDatesChangedEventArgs`.
```
public class SchedulerPageBehavior : Behavior<ContentPage>
{
    SfSchedule schedule;
    protected override void OnAttachedTo(ContentPage bindable)
    {
        base.OnAttachedTo(bindable);
        this.schedule = bindable.Content.FindByName<SfSchedule>("Schedule");
        this.WireEvents();
    }
    private void WireEvents()
    {
        this.schedule.VisibleDatesChangedEvent += Schedule_VisibleDatesChangedEvent;
    }
 
    private void Schedule_VisibleDatesChangedEvent(object sender, VisibleDatesChangedEventArgs e)
    {
        var month = e.visibleDates[e.visibleDates.Count / 2].Date.Month;
        var year = e.visibleDates[e.visibleDates.Count / 2].Date.Year;
        App.Current.MainPage.DisplayAlert(month.ToString(), year.ToString(), "Ok");
    }
    protected override void OnDetachingFrom(ContentPage bindable)
    {
        base.OnDetachingFrom(bindable);
        this.UnWireEvents();
    }
    private void UnWireEvents()
    {
        this.schedule.VisibleDatesChangedEvent += Schedule_VisibleDatesChangedEvent;
    }
}
```

KB article - [How to get the month and year of month view in Xamarin.Forms Schedule (SfScheduler)](https://www.syncfusion.com/kb/12199/how-to-get-the-month-and-year-of-month-view-in-xamarin-forms-schedule-sfschedule)