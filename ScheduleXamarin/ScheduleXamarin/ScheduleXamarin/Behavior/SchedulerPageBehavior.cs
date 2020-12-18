using Syncfusion.SfSchedule.XForms;
using Xamarin.Forms;

namespace ScheduleXamarin
{
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
}


