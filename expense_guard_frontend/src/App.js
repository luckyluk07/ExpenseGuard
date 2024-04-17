import './App.css';
import ExpenseBadge from './Components/Finance/ExpenseBadge/ExpenseBadge';
import Button from './Components/Common/Button/Button';
import InvestmentDepositBadge from './Components/Finance/InvestmentDeposit/InvestmentDepositBadge';
import IncomeBadge from './Components/Finance/IncomeBadge/IncomeBadge';
import Dropdown from './Components/Forms/Dropdown/Dropdown';
import TextInput from './Components/Forms/TextInput/TextInput';
import Heading from './Components/Common/Heading/Heading';
import Text from './Components/Common/Text/Text'
import ActionCard from './Components/Finance/ActionCard/ActionCard';
import CurrenciesTable from './Components/Finance/CurrenciesTable/CurrenciesTable';

function App() {
  return (
    <div className="App">
      <main>
        <div class='container'>
          <h2>Expense badge example</h2>
          <ExpenseBadge name='Netflix subscription' money={{amount: 100, currency: {code: "PLN"}}} description='Monthly Netflix subscription bill'/>
          <h2>Button example</h2>
          <Button text='Button text' onClick={() => {console.log('button click')}}/>
          <h2>Investment deposit badge</h2>
          <InvestmentDepositBadge name='PKO BP - konto dla nowych' startDate='17 April 2024' endDate='17 June 2024' startMoney={{amount: 200000, currency: {code: "PLN"}}} yearCapitalizationAmount={4} interestRate={6.0} />
          <h2>Income badge</h2>
          <IncomeBadge name='Salary' category={{name: 'job'}} money={{amount: 10000, currency: {code: "PLN"}}} receivedDate='10 April 2024'/>
          <h2>Dropdown</h2>
          <Dropdown options={[{name: 'option1'}, {name: 'option2'}, {name: 'option3'}]}/>
          <h2>Text input component</h2>
          <TextInput labelText={'Example text input'} inputId={'exampleId'} placeholder={'Type your example text...'}/>
          <h2>Heading component</h2>
          <Heading text='Heading example text' size={1}/>
          <h2>Text</h2>
          <Text content='Examnple content of text' bold={true} fontSize={40}/>
          <h2>Action card</h2>
          <ActionCard category='income' name='salary' amount={11_000} currency='PLN' />
          <h2>Currencies table</h2>
          <CurrenciesTable currencies={[{name: 'PLN', price: 4.59},{name: 'USD', price: 1.52},{name: 'EUR', price: 1.10}]}/>
        </div>
      </main>
    </div>
  );
}

export default App;
