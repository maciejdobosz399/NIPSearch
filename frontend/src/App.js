import "./App.css";

import { useState } from "react";
import axios from "axios";
import EnterpreneurData from "./components/EnterpreneurData";

const apiUrl = "http://localhost:5008/Entrepreneur/";

function App() {
  const [inputValue, setInputValue] = useState("");
  const [entrepreneur, setEnterpreneur] = useState({});
  const [error, setError] = useState("");

  function handleButtonClick(e) {
    if (inputValue.trim().length == 0) {
      alert("Podaj NIP.");
      return;
    }

    axios
      .get(`${apiUrl}${inputValue}`)
      .then((res) => {
        switch (res.status) {
          case 200:
            console.log(res.data);
            setEnterpreneur(res.data);
            setError("");
            break;
          default:
            setEnterpreneur("");
            setError(res.data);
            break;
        }
      })
      .catch((res) => {
        if (!res) {
          setError("Coś poszło nie tak");
          return;
        }

        setError(res.response.data);
        setEnterpreneur({});
        console.error(res);
      });
  }

  return (
    <div className="App">
      <div className="flex w-100 min-h-screen justify-center items-center bg-slate-100">
        <div className="w-1/4 h-30 p-6 bg-white rounded shadow-lg flex justify-center items-center flex-col">
          <h5 className="font-bold text-center text-lg text-gray-700">
            Wyszukaj przedsiębiorce!
          </h5>
          <input
            value={inputValue}
            onChange={(e) => setInputValue(e.target.value)}
            type="text"
            className="mt-7 w-1/2 p-1 rounded border-2 border-slate-400 text-gray-700"
            placeholder="Podaj NIP"
          ></input>
          <button
            onClick={handleButtonClick}
            className="mt-7 pl-4 pr-4 pt-2 pb-2 text-white rounded bg-blue-500"
          >
            Szukaj!
          </button>

          <div className="mt-6 flex justify-center flex-col">
            {Object.keys(entrepreneur).length > 0 && (
              <EnterpreneurData {...entrepreneur}></EnterpreneurData>
            )}

            {error != "" && (
              <div>
                <h2 className="text-red-600 font-bold text-center">{error}</h2>
              </div>
            )}
          </div>
        </div>
      </div>
    </div>
  );
}

export default App;
