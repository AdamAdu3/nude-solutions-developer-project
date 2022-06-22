import React from 'react';
import CustomDropdown from './Dropdown';
import styled from 'styled-components';

const Title = styled.h3`
      color: blue;
    `;


const NewItemForm = (props) => {
    const createNewItemAction = props.createNewItemAction;
    const highValueCategories = props.highValueCategories;
    const setFormInputsAction = props.setFormInputsAction;


    //Function that handles the change action of the create new item form.
    const handleFormChange = (event) => {
        const name = event.target.name;
        const value = event.target.value;
        setFormInputsAction(values => ({ ...values, [name]: event.target.type === 'select-one' ? parseInt(value, 10) : value }));
    }

    //Function that handles the submit action of the create new item form.
    const handleSubmit = (event) => {
        event.preventDefault();
        createNewItemAction();
    }

    return (
        <div>
            <form onSubmit={handleSubmit}>
                <Title>Add New:</Title>
                <table>
                    <tbody>
                        <tr>
                            <td>Name:</td>
                            <td><input required type="text" name="name" onChange={handleFormChange} /></td>
                        </tr>
                        <tr>
                            <td>Value:</td>
                            <td><input required type="number" step="0.01" name="value" onChange={handleFormChange} /></td>
                        </tr>
                        <tr>
                            <td>Category:</td>
                            <td><CustomDropdown header='Select Category'
                                selections={highValueCategories} onChange={handleFormChange}
                                name="itemCategory" /> </td>
                        </tr>
                        <tr>
                            <td><input type="submit" value="Submit" /></td>
                        </tr>
                    </tbody>
                </table>
            </form>
        </div>
    )
}

export default NewItemForm;