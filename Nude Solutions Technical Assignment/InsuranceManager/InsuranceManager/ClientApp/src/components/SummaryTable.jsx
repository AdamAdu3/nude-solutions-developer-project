import React, { Fragment } from 'react';
import { Table } from 'react-bootstrap';


const SummaryTable = (props) => {
    const values = props.values;
    const onDelete = props.onDelete;
    const formatter = props.formatter;

    return (
        <Table striped bordered hover size="sm">
            <tbody>
                {
                    values.map((child, i) => (
                        <Fragment key={i}>
                            <tr>
                                <td>{child.name}</td>
                                <td>{formatter.format(child.value)}</td>
                                <td><button className="deleteButton" onClick={() => onDelete(child.id)}></button></td>
                            </tr>
                        </Fragment>
                    ))
                }
            </tbody>
        </Table>
    )
};

export default SummaryTable;