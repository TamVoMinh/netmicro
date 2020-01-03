import React from 'react';
import logo from './logo.svg';
import './App.css';
import { CONST } from 'nmcro-lib';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.js</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Short date format {CONST.FORMAT_SHORT_DATE}
        </a>
      </header>
    </div>
  );
}

export default App;
