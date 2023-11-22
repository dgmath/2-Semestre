import React from "react";
import "./TableE.css";
import editPen from "../../../Assets/images/edit-pen.svg"
import trashDelete from "../../../Assets/images/trash-delete.svg"


const TableE = ({dados, fnUpdate, fnDelete}) => {
    console.log(dados);

  return (
    <table className="table-data">
      <thead className="table-data__head">
        <tr className="table-data__head-row">
          <th className="table-data__head-title table-data__head-title--big">
            Evento
          </th>
          <th className="table-data__head-title table-data__head-title--little">
            Descrição
          </th>
          <th className="table-data__head-title table-data__head-title--little">
            Tipo Evento
          </th>
          <th className="table-data__head-title table-data__head-title--little">
            Data
          </th>
          <th className="table-data__head-title table-data__head-title--little">
            Editar
          </th>
          <th className="table-data__head-title table-data__head-title--little">
            Deletar
          </th>

        </tr>
      </thead>

      <tbody>

            {dados.map((e) => {
                return(
                    //uma linha completa
                    <tr className="table-data__head-row">

                    <td className="table-data__data table-data__data--big">
                      {e.nomeEvento}
                    </td>
                      <td className="table-data__data table-data__data--little">
                        {e.descricao}
                      </td>
                    <td className="table-data__data table-data__data--little">
                      {e.tiposEvento.titulo}
                    </td>
                    <td className="table-data__data table-data__data--little">
                      {new Date(e.dataEvento).toLocaleDateString()}
                    </td>

                    <td className="table-data__data table-data__data--little">
                    <img 
                          onClick={() => {
                            //adicionando o id do evento para a função
                              fnUpdate(e.idEvento);
                          }}
                          className="table-data__icon" 
                          src={editPen} 
                          alt="" />
                    </td>
                    <td className="table-data__data table-data__data--little">
                    <img 
                          onClick={() => {
                              fnDelete(e.idEvento);
                          }}
                          className="table-data__icon" 
                          src={trashDelete} 
                          alt="" />
                    </td>
                  </tr>
                )
            })}

      </tbody>

    </table>
  );
  // <table>
  //     {/* cabeçalho */}
  //     <thead>
  //         <tr>
  //             <th>Titulo</th>
  //             <th>Editar</th>
  //             <th>Apagar</th>
  //         </tr>
  //     </thead>

  //     {/* corpo */}
  //     <tbody>
  //         <tr>
  //             <td>Eventos</td>
  //             <td>Eventos</td>
  //             <td>Eventos</td>
  //         </tr>
  //     </tbody>
  // </table>
};

export default TableE;
