import React from "react";

const EnterpreneurData = ({ name, nip, regon, address }) => {
  return (
    <div>
      <h2 className="text-green-600 font-bold text-center">Znaleziono!</h2>
      <span className="text-m text-center mt-2">
        <h5>
          Nazwa: <span className="font-bold">{name}</span>
        </h5>
        <h5>
          Nip: <span className="font-bold">{nip}</span>
        </h5>
        <h5>
          Regon: <span className="font-bold">{regon}</span>
        </h5>
        <h5>
          Adres: <span className="font-bold">{address}</span>
        </h5>
      </span>
    </div>
  );
};

export default EnterpreneurData;
