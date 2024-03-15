import React, { useEffect, useState } from 'react';
import '../Styles/Nonfiction.css';
import { useNavigate } from 'react-router-dom';
import { Button, ButtonGroup } from 'react-bootstrap';
import Book from '../Components/Book.jsx';

function Nonfiction() {
    const [nonfictionData, setNonfictionData] = useState([]);

    const history = useNavigate();

    const handleNavigation = (route) => {
        history(route);
    }

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await fetch('https://localhost:7284/api/Nonfiction/GetAll', {
                    method: 'GET',
                    headers: {
                        accept: 'application/json'
                    }
                });
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }

                const data = await response.json();
                setNonfictionData(data);
                console.log(data);

            } catch (error) {
                console.error('Error fetching data:', error);
            }
        };

        fetchData();
    }, []);

    return (
        <div className='nonfiction-page'>
            <h1 className='nonfiction-page-header'>Nonfiction</h1>
            <ButtonGroup className='nonfiction-btn' aria-label="nonfiction btns" >
                <Button variant='primary' onClick={() => handleNavigation('/fiction')}>
                    Fiction
                </Button>
                <Button variant='primary' onClick={() => handleNavigation('/nonfiction')}>
                    Nonfiction
                </Button>
            </ButtonGroup>
            <div className='nonfiction-book-data'>
                {nonfictionData.map((item, index) => (
                    <Book key={index} data={item} />
                ))}
            </div>
        </div>
    )
}

export default Nonfiction;