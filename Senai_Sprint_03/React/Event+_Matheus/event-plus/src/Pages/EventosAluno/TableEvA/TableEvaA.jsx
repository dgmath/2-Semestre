import React from "react";
import comentaryIcon from "../../../Assets/images/comentary-icon.svg";
import trashDelete from "../../../Assets/images/trash-delete.svg";
import { dateFormatDbToView } from "../../../Utils/stringFunction";
import ToggleSwitch from "../../../Components/Toggle/Toggle";
// importa a biblioteca de tootips ()
import "react-tooltip/dist/react-tooltip.css";
import { Tooltip } from "react-tooltip";

// import trashDelete from "../../../assets/images/trash-delete.svg";
import "./TableEvA.css";

const Table = ({ dados, fnConnect = null, fnShowModal = null }) => {
  return (
    <table className="tbal-data">
      <thead className="tbal-data__head">
        <tr className="tbal-data__head-row tbal-data__head-row--red-color">
          <th className="tbal-data__head-title tbal-data__head-title--big">
            Evento
          </th>
          <th className="tbal-data__head-title tbal-data__head-title--big">
            Data
          </th>
          <th className="tbal-data__head-title tbal-data__head-title--big">
            Ações
          </th>
        </tr>
      </thead>
      <tbody>
        {dados.map((e) => {
          return (
            <tr className="tbal-data__head-row" key={Math.random()}>
              <td className="tbal-data__data tbal-data__data--big">
                {e.nomeEvento}
              </td>
              
              <td className="tbal-data__data tbal-data__data--big tbal-data__btn-actions">
                {/* {e.dataEvento} */}
                {dateFormatDbToView(e.dataEvento)}
              </td>

              <td className="tbal-data__data tbal-data__data--big tbal-data__btn-actions">
                <img
                  className="tbal-data__icon"
                  idevento={e.idEvento}
                  src={comentaryIcon}
                  alt=""
                  onClick={fnShowModal}
                />

                {/* Prop drilling onde passo uma prop para o pai pro filhob e para o neto, seria o fnconnect */}
                <ToggleSwitch 
                toggleActive={e.situacao}
                 manipulationFunction={() => {
                  fnConnect(
                    e.idEvento,
                    e.situacao ? "unconnect" : "connect",
                    e.idPresencaEvento
                  )
                 }} />
              </td>
            </tr>
          );
        })}
      </tbody>
    </table>
  );
};

export default Table;
