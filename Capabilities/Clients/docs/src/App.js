import React from 'react';
import SwaggerUI from "swagger-ui-react";
import "swagger-ui-react/swagger-ui.css"

function App() {
  return (
    <div className="App">
      <SwaggerUI url="http://api.nmro.local/oas/iams/swagger.json" />
    </div>
  );
}

export default App;
