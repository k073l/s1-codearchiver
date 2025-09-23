using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AssemblyDecompiler;

public class SignatureStripper : CSharpSyntaxRewriter
{
    public override SyntaxNode VisitMethodDeclaration(MethodDeclarationSyntax node)
    {
        var newNode = node.WithBody(null).WithExpressionBody(null)
            .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));
        return base.VisitMethodDeclaration(newNode);
    }

    public override SyntaxNode VisitConstructorDeclaration(ConstructorDeclarationSyntax node)
    {
        var newNode = node.WithBody(null).WithInitializer(null).WithExpressionBody(null)
            .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));
        return base.VisitConstructorDeclaration(newNode);
    }

    public override SyntaxNode VisitPropertyDeclaration(PropertyDeclarationSyntax node)
    {
        if (node.AccessorList != null)
        {
            var accessors = node.AccessorList.Accessors.Select(a =>
                a.WithBody(null).WithExpressionBody(null)
                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken))).ToList();
            var newAccessorList = SyntaxFactory.AccessorList(SyntaxFactory.List(accessors));
            var newNode = node.WithAccessorList(newAccessorList);
            return base.VisitPropertyDeclaration(newNode);
        }

        return base.VisitPropertyDeclaration(node);
    }

    public override SyntaxNode VisitEventDeclaration(EventDeclarationSyntax node)
    {
        if (node.AccessorList != null)
        {
            var accessors = node.AccessorList.Accessors.Select(a =>
                a.WithBody(null).WithExpressionBody(null)
                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken))).ToList();
            var newAccessorList = SyntaxFactory.AccessorList(SyntaxFactory.List(accessors));
            var newNode = node.WithAccessorList(newAccessorList);
            return base.VisitEventDeclaration(newNode);
        }

        return base.VisitEventDeclaration(node);
    }

    public override SyntaxNode VisitFieldDeclaration(FieldDeclarationSyntax node)
    {
        var variables = node.Declaration.Variables.Select(v => v.WithInitializer(null)).ToList();
        var decl = node.Declaration.WithVariables(SyntaxFactory.SeparatedList(variables));
        var newNode = node.WithDeclaration(decl);
        return base.VisitFieldDeclaration(newNode);
    }

    public override SyntaxNode VisitAccessorDeclaration(AccessorDeclarationSyntax node)
    {
        var newNode = node.WithBody(null).WithExpressionBody(null)
            .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));
        return base.VisitAccessorDeclaration(node);
    }

    public override SyntaxNode VisitAnonymousMethodExpression(AnonymousMethodExpressionSyntax node)
    {
        return SyntaxFactory.ParseExpression("default");
    }

    public override SyntaxNode VisitSimpleLambdaExpression(SimpleLambdaExpressionSyntax node)
    {
        return SyntaxFactory.ParseExpression("default");
    }

    public override SyntaxNode VisitParenthesizedLambdaExpression(ParenthesizedLambdaExpressionSyntax node)
    {
        return SyntaxFactory.ParseExpression("default");
    }
}