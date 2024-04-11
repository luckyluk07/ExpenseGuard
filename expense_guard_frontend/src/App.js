import './App.css';
import ExpenseBadge from './Components/ExpenseBadge/ExpenseBadge';
import Button from './Components/Common/Button/Button';
import InvestmentDepositBadge from './Components/InvestmentDeposit/InvestmentDepositBadge';
import IncomeBadge from './Components/IncomeBadge/IncomeBadge';

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
        <h2>Income badge</h2>
        <IncomeBadge name='Salary' category={{name: 'job'}} money={{amount: 10000, currency: {code: "PLN"}}} receivedDate='10 April 2024'/>
      </main>
    </div>
  );
}

export default App;
