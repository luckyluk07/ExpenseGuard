import './App.css';
import ExpenseBadge from './Components/ExpenseBadge/ExpenseBadge';
import Button from './Components/Common/Button/Button';

function App() {
  return (
    <div className="App">
      <main>
        <h2>Expense badge example</h2>
        <ExpenseBadge name='Netflix subscription' money={{amount: 100, currency: {code: "PLN"}}} description='Monthly Netflix subscription bill'/>
        <h2>Button example</h2>
        <Button text='Button text' onClick={() => {console.log('button click')}}/>

      </main>
    </div>
  );
}

export default App;
