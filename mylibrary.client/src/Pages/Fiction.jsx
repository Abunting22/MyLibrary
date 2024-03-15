import React, { useEffect, useState} from 'react';
import '../Styles/Fiction.css';
import { useNavigate } from 'react-router-dom';
import { Button, ButtonGroup } from 'react-bootstrap';
import Book from '../Components/Book.jsx';

function Fiction() {
    const [fictionData, setFictionData] = useState([]);

    const history = useNavigate();

    const handleNavigation = (route) => {
        history(route);
    }

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await fetch('https://localhost:7284/api/Fiction/GetAll', {
                    method: 'GET',
                    headers: {
                        accept: 'application/json'
                    }
                });
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }

                const data = await response.json();
                setFictionData(data);
                console.log(data);

            } catch (error) {
                console.error('Error fetching data:', error);
            }
        };

        fetchData();
    }, []);

    return (
        <div className='fiction-page'>
            <h1 className='fiction-page-header'>Fiction</h1>
            <ButtonGroup className='fiction-btn' aria-label="fiction btns" >
                <Button variant='primary' onClick={() => handleNavigation('/fiction')}>
                    Fiction
                </Button>
                <Button variant='primary' onClick={() => handleNavigation('/nonfiction')}>
                    Nonfiction
                </Button>
            </ButtonGroup>
            <div className='fiction-book-data'>
                {fictionData.map((item, index) => (
                    <Book key={index} data={item} />
                ))}
            </div>
        </div>
    );
}

export default Fiction;