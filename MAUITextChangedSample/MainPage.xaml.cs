namespace MAUITextChangedSample
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        int denom = 500;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private void quantityInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            count++;
            lblQuantityChangeIndicator.Text = "Quantity Text Changed: " + count.ToString();

            int.TryParse(e.NewTextValue, out int quantity);

            amountInput.Text = (quantity * denom).ToString();
        }

        private void amountInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            count++;
            lblAmountChangeIndicator.Text = "Amount Text Changed: " + count.ToString();

            int.TryParse(e.NewTextValue, out int amount);
            quantityInput.Text = (amount / denom).ToString();
        }

        private void quantityInput_Unfocused(object sender, FocusEventArgs e)
        {
            count++;
            lblQuantityUnfocusIndicator.Text = "Quantity Unfocused: " + count.ToString();
        }

        private void amountInput_Unfocused(object sender, FocusEventArgs e)
        {
            count++;
            lblAmountUnfocusIndicator.Text = "Amount Unfocused: " + count.ToString();

            int.TryParse(amountInput.Text, out int amount);

            if (amount % denom != 0)
            {
                DisplayAlert("Invalid Input", "Amount should be multiple of 500", "Ok");
                amountInput.Text = string.Empty;
            }
        }
    }

}
