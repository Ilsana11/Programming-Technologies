namespace Bank;

public class Transfer
{
    public void Execute(BankAccount from, BankAccount to, decimal amount, 
        DateTime date, string note)
    {
        ArgumentNullException.ThrowIfNull(from);
        ArgumentNullException.ThrowIfNull(to);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);

        if(from == to)
        {
            throw new InvalidOperationException("нельзя перевести на тот же счет");
        }
        if (!from.CanWithdraw(amount))
        {
            throw new InvalidOperationException($"Недостаточно стредств на счете {from.Number} для перевода { amount} ");
        }

        from.MakeWithdrawal(amount, date, $"transfer to {to.Number}:{note} ");
        to.MakeDeposite(amount, date, $"transfer from {from.Number}:{note}");
    }
}
