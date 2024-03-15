import React from 'react';
import { useNavigate } from 'react-router-dom';
import { Button, ButtonGroup } from 'react-bootstrap';
import { HiBeaker } from "react-icons/hi";
import { GiAstronautHelmet } from "react-icons/gi";
import '../Styles/Start.css';

function Start() {
    const history = useNavigate();

    const handleNavigation = (route) => {
        history(route);
    }

    return (
        <div className='start-page'>
            <h1 className='start-page-header'>My Library</h1>
            <ButtonGroup className='header-btn' aria-label="Header btns" >
                <Button variant='primary' onClick={() => handleNavigation('/fiction')}>
                    <span className='icon'><GiAstronautHelmet /></span>
                    Fiction
                </Button>
                <Button variant='primary' onClick={() => handleNavigation('/nonfiction')}>
                    <span className='icon'><HiBeaker /></span>
                    Nonfiction
                </Button>
            </ButtonGroup>    
        </div>
        
    )
}

export default Start;