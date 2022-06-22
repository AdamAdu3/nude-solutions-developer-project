import React from 'react';
import { Form } from 'react-bootstrap'

const CustomDropdown = (props) => {
    const selections = props.selections;

    return (
        <Form.Select onChange={props.onChange} name={props.name} defaultValue="1">
            {
                Object.entries(selections).map(([key, value]) => (
                    <option key={key} value={key}>{value}</option>
                ))
            }
        </Form.Select>
    );
};

export default CustomDropdown;