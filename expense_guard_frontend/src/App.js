import './App.css';
import ExpenseBadge from './Components/ExpenseBadge/ExpenseBadge';
import Button from './Components/Common/Button/Button';
import InvestmentDepositBadge from './Components/InvestmentDeposit/InvestmentDepositBadge';

function App() {
  return (
    <div className="App">
      <main>
        <h2>Expense badge example</h2>
        <ExpenseBadge name='Netflix subscription' money={{amount: 100, currency: {code: "PLN"}}} description='Monthly Netflix subscription bill'/>
        <h2>Button example</h2>
        <Button text='Button text' onClick={() => {console.log('button click')}}/>
        <h2>Investment deposit badge</h2>
        <InvestmentDepositBadge name='PKO BP - konto dla nowych' startDate='17 April 2024' endDate='17 June 2024' startMoney={{amount: 200000, currency: {code: "PLN"}}} yearCapitalizationAmount={4} interestRate={6.0} />
        {/* <div className='containerSkin containerShape'>
        <h3>{props.name}</h3>
        <h4>Date range: {props.startDate} - {props.endDate}</h4>
        <h4>{props.startMoney.amount} {props.startMoney.currency.code}</h4>
        <p>Year capitalization: {props.yearCapitalizationAmount}</p> */}
      </main>
    </div>
  );
}

export default App;
