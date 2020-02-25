import React from 'react';
import SwaggerUI from "swagger-ui-react";
import "swagger-ui-react/swagger-ui.css"

function App() {
  return (
    <div className="App">
      <SwaggerUI url="http://api.nmro.local/iam/oas/v1/swagger.json/" />
    </div>
  );
}

export default App;
