import './App.css';
import ExpenseBadge from './Components/ExpenseBadge';

function App() {
  return (
    <div className="App">
      <main>
        <h2>Expense badge example</h2>
        <ExpenseBadge name='Netflix subscription' money={{amount: 100, currency: {code: "PLN"}}} description='Monthly Netflix subscription bill'/>
      </main>
    </div>
  );
}

export default App;
