import styled from 'styled-components';

//Styled component for a category header
export const CategoryHeader = styled.h4`
        display: inline-block;
        text-align: ${props => props.$title ? "left" : "right"};
        width: ${props => props.$title ? "50%" : "49%"};
        font-weight : bold
`;