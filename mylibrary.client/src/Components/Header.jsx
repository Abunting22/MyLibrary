import React from 'react';
import { Button, ButtonGroup } from 'react-bootstrap';
import { useNavigate } from 'react-router-dom';
import '../Styles/Header.css';
import Sort from './Sort';
import Add from './Add';
function Header() {
    const history = useNavigate();

    const handleNavigation = (route) => {
        history(route);
    }

    let page = window.location.pathname === '/fiction' ? 'Fiction' : 'Nonfiction';

    return (
        <div className='header'>
            <h1 className='page-header'>{page}</h1>
            <ButtonGroup className='header-btns'>
                <Button variant='primary' onClick={() => handleNavigation('/fiction')}>
                    Fiction
                </Button>
                <Button variant='primary' onClick={() => handleNavigation('/nonfiction')}>
                    Nonfiction
                </Button>
                <Add className='add-btn' />
                <Sort className='sort-btn'/>
            </ButtonGroup>
        </div>
    );
}

export default Header;