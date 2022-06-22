import React, { Fragment, useEffect, useState } from 'react';
import SummaryTable from './SummaryTable';
import NewItemForm from './NewItemForm';
import '../styles/Home.css';
import { CategoryHeader } from './StyledComponents'

const Home = () => {
    const [highValueItems, setHighValueItems] = useState([]);
    const [highValueCategories, setHighValueCategories] = useState([]);
    const [formInputs, setFormInputs] = useState([]);
    const [isSubmitted, setIsSubmitted] = useState([{ value: false }]);
    const [grandTotal, setGrandTotal] = useState(0);

    //Setup the hook to fetch the high value items.
    useEffect(() => {
        fetch('api/HighValueItem/GetHighValueItems')
            .then(response => response.json())
            .then(data => {
                setHighValueItems(data);
                calculateGrandTotal(data);
            })
    }, [isSubmitted]);

    //Setup the hook to fetch the high value item categories.
    useEffect(() => {
        fetch('api/HighValueItem/GetHighValueCategories')
            .then(response => response.json())
            .then(data => setHighValueCategories(data))
    }, []);

    //Function to calculate the grand total of all added high value items.
    const calculateGrandTotal = (data) =>
    {
        var total = 0;
        for (const [, value] of Object.entries(data)) {
            total += value.reduce((accumulator, curValue) => accumulator + curValue.value, 0);
        }
        setGrandTotal(total);
    }

    //Function to create a new high value item.
    const createNewItem = () => {
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(formInputs)
        };
        fetch('api/HighValueItem/CreateHighValueItem', requestOptions)
            .then(response => setIsSubmitted({value : true}));
    }

    //Function to handle the delete action of a high value item.
    const onDeleteItem = (id) =>
    {
        const requestOptions = {
            method: 'DELETE',
            headers: { 'Content-Type': 'application/json' },
        };

        fetch('api/HighValueItem/DeleteHighValueItem/' + id, requestOptions)
            .then(response => setIsSubmitted({ value: true }));
    }

    //Function to format a number for display purposes.
    var formatter = new Intl.NumberFormat('en-us', {
        style: 'currency',
        currency: 'USD'
    });

    return (
        <div>   
            {
                Object.keys(highValueItems).length === 0 ?
                    <p>There are currently no items. Please add an item using the form below.</p> :
                    <div>
                        {
                            Object.entries(highValueItems).map(([key, value]) => (
                                <Fragment key={key}>
                                    <CategoryHeader $title="true">{key}</CategoryHeader>
                                    <CategoryHeader>Total: {formatter.format(value.reduce((accumulator, curValue) => accumulator + curValue.value, 0))}</CategoryHeader>
                                    <SummaryTable values={value} onDelete={onDeleteItem} formatter={formatter} />
                                </Fragment>
                            ))
                        }
                        <h2><b>Grand total: {formatter.format(grandTotal)}</b></h2>
                    </div>
            }  
            <NewItemForm
                createNewItemAction={createNewItem}
                setFormInputsAction={setFormInputs}
                highValueCategories={highValueCategories} />
        </div>
    );
}

export default Home;

