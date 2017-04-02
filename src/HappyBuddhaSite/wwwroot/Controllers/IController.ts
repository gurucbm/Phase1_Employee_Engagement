export interface IController
{
}

export interface IControllerFactory
{
	CreateInstance(): IController;
}